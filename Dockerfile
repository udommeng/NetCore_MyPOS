FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
#EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MyPOS.csproj", "./"]
RUN dotnet restore "./MyPOS.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MyPOS.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyPOS.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyPOS.dll"]
