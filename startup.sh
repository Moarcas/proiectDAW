#!/bin/bash

ANGULAR=proiectDAWAngular
DOTNETLOG=dotnet.log
NGLOG=ng.log

# Rulare server .NET
dotnet run > /dev/null 2>&1 >> $DOTNETLOG &
echo "Running .NET server..."

# Rulare server Angular
cd $ANGULAR && nohup ng serve > /dev/null 2>&1 >> $NGLOG &
echo "Running Angular server..."

echo "Servers started successfully."

echo "Press q to stop the servers."

while true; do
    read -r -n 1 key
    if [[ $key == "q" ]]; then
        break
    fi
done

echo ""
echo "Stopping servers..."

kill -9 $(lsof -i:8080 -t) 2> /dev/null
kill -9 $(lsof -i:4200 -t) 2> /dev/null