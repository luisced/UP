#!/bin/bash

# Host and port are passed as arguments
host="$1"
shift
port="$1"
shift
cmd="$@"

# Wait for the host:port to be available (MySQL is ready)
until nc -z -v -w30 $host $port
do
  echo "Waiting for database connection..."
  # wait for 5 seconds before check again
  sleep 5
done

# Run the main command
exec $cmd
