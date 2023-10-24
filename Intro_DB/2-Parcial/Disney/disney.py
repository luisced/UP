import csv
import sqlite3
from sqlite3 import Error
from prettytable import PrettyTable

def create_connection(db_file):
    """Create a database connection to the SQLite database specified by db_file"""
    conn = None
    try:
        conn = sqlite3.connect(db_file)
    except Error as e:
        print(e)
    
    return conn

def create_table(conn):
    """Create a table using the provided SQL statement"""
    try:
        sql_create_disneyland_reviews_table = """CREATE TABLE IF NOT EXISTS DisneylandReviews (
                                                    Review_ID INTEGER PRIMARY KEY,
                                                    Rating INTEGER,
                                                    Year_Month TEXT,
                                                    Reviewer_Location TEXT,
                                                    Review_Text TEXT,
                                                    Branch TEXT
                                                );"""
        c = conn.cursor()
        c.execute(sql_create_disneyland_reviews_table)
    except Error as e:
        print(e)

def drop_table(conn):
    """Drop the DisneylandReviews table"""
    try:
        sql_drop_disneyland_reviews_table = "DROP TABLE IF EXISTS DisneylandReviews;"
        c = conn.cursor()
        c.execute(sql_drop_disneyland_reviews_table)
    except Error as e:
        print(e)

def insert_data_from_csv(conn, csv_file_path):
    """Insert data from a CSV file into the SQLite table"""
    try:
        cursor = conn.cursor()
        with open(csv_file_path, 'r', encoding='ISO-8859-1') as csvfile:
            csv_reader = csv.reader(csvfile)
            next(csv_reader, None)  # Skip the header row
            for row in csv_reader:
                cursor.execute("INSERT OR IGNORE INTO DisneylandReviews (Review_ID, Rating, Year_Month, Reviewer_Location, Review_Text, Branch) VALUES (?, ?, ?, ?, ?, ?)", row)
        conn.commit()
    except Error as e:
        print(e)



def main():
    database = r"pythonsqlite.db"  # Specify the path to your database here

    # Create a database connection
    conn = create_connection(database)

    if conn is not None:
        # Drop the table if needed
        drop_table(conn)

        # Create tables
        create_table(conn)

        # Insert data from CSV
        csv_file_path = 'DisneylandReviews.csv'  # Specify the path to your CSV file here
        insert_data_from_csv(conn, csv_file_path)

    else:
        print("Error! Cannot create the database connection.")

    # Close the connection
    if conn:
        conn.close()

if __name__ == '__main__':
    main()

