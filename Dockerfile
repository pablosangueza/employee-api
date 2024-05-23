FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
EXPOSE 8080
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:8.0 as devbase
WORKDIR /src

FROM devbase as build
COPY . .
RUN dotnet build "EmployeeAPI.sln" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EmployeeAPI/EmployeeAPI.csproj" -c Release -o /app

FROM base as final
RUN sed 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/' /etc/ssl/openssl.cnf > /etc/ssl/openssl.cnf.changed && mv /etc/ssl/openssl.cnf.changed /etc/ssl/openssl.cnf
WORKDIR /app

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeAPI.dll"]