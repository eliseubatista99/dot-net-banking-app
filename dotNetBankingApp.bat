#!/bin/sh

dotnet run --project "DotNetBankingAppApi/DotNetBankingAppApi" &
dotnet watch --project "DotNetBankingAppClient/DotNetBankingAppClient"
echo 'Project has started'