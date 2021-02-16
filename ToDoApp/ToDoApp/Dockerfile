FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ToDoApp.csproj", "ToDoApp/"]
RUN dir 
RUN dir /ToDoApp
RUN dotnet restore "ToDoApp/ToDoApp.csproj"
WORKDIR /src/ToDoApp
RUN dir
RUN dotnet restore "./ToDoApp.csproj"
RUN dir
COPY . .
RUN dir
WORKDIR "/src/ToDoApp"
RUN dir
RUN dotnet build "ToDoApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.dll"]
