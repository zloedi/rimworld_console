debug:
	rm ./bin/Debug/Qonsole.dll ; make ./bin/Debug/Qonsole.dll

release:
	rm ./bin/Release/Qonsole.dll ; make ./bin/Release/Qonsole.dll

all: debug release \


./bin/Debug/Qonsole.dll:
	dotnet build Qonsole.csproj --nologo --configuration Debug \

./bin/Release/Qonsole.dll:
	dotnet build Qonsole.csproj --nologo --configuration Release \

clean: 
	dotnet clean Qonsole.csproj \

