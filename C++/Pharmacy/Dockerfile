# Use an official C++ base image
FROM gcc:latest

# Set the working directory in the container to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
ADD . /app

# Install MySQL Connector and netcat for our script
RUN apt-get update && \
    apt-get -y install libmysqlcppconn-dev netcat

# Make port 80 available to the world outside this container
EXPOSE 80

# Compile your C++ program
RUN g++ -o myapp main.cpp -lmysqlcppconn

# Copy the script into the image
COPY wait-for-it.sh /usr/local/bin/wait-for-it.sh
RUN chmod +x /usr/local/bin/wait-for-it.sh

# Run the command via the script
CMD ["wait-for-it.sh", "db:3306", "./myapp"]
