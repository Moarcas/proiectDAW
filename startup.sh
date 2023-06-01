#!/bin/bash

ANGULAR=proiectDAWAngular
DOTNETLOG=dotnet.log
NGLOG=ng.log
POSTGRES=postgresDAW
POSTGRESPORT=5432

docker version;
retVal=$?;

if [ $retVal -ne 0 ]; then
	echo "Docker must be installed to run this script. Install Docker and try again.";
	exit 1;
fi

docker container inspect $POSTGRES > /dev/null 2>&1;
retVal2=$?;

if [ $retVal2 -ne 0 ]; then
    docker run -p $POSTGRESPORT:$POSTGRESPORT --name $POSTGRES -e POSTGRES_PASSWORD=mysecretpassword -d postgres > /dev/null;
fi

docker start $POSTGRES > /dev/null;

# Rulare server .NET
dotnet watch > /dev/null 2>&1 >> $DOTNETLOG &
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

docker stop $POSTGRES > /dev/null 2>&1;

echo ""
echo "Stopped postgres container";

echo "Stopping servers..."

kill -9 $(lsof -i:8080 -t) 2> /dev/null
kill -9 $(lsof -i:4200 -t) 2> /dev/null