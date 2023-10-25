import sqlite3
from sqlite3 import Error

def crear_conexion(db_file):
    """ 
    Crear una conexión de base de datos al archivo SQLite especificado.
    Si el archivo no existe, se creará.
    """
    conn = None
    try:
        conn = sqlite3.connect(db_file)
        return conn
    except Error as e:
        print(e)

    return conn

def crear_tabla(conn, create_table_sql):
    """ 
    Crear una tabla usando la conexión y la declaración SQL proporcionadas.
    """
    try:
        c = conn.cursor()
        c.execute(create_table_sql)
    except Error as e:
        print(e)

def main():
    database = "py_formula1.db"

    sql_crear_tabla_drivers = """ CREATE TABLE IF NOT EXISTS drivers (
                                        driver_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        name TEXT NOT NULL,
                                        team TEXT NOT NULL,
                                        birth_date TEXT NOT NULL,
                                        is_world_champion INTEGER NOT NULL
                                    ); """

    sql_crear_tabla_race_events = """CREATE TABLE IF NOT EXISTS race_events (
                                        event_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        driver_id INTEGER NOT NULL,
                                        description TEXT NOT NULL,
                                        event_time TEXT NOT NULL,
                                        duration_seconds INTEGER NOT NULL,
                                        FOREIGN KEY (driver_id) REFERENCES drivers (driver_id)
                                    );"""

    sql_crear_tabla_race_statistics = """CREATE TABLE IF NOT EXISTS race_statistics (
                                            statistics_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            driver_id INTEGER NOT NULL,
                                            race_id INTEGER NOT NULL,
                                            laps_completed INTEGER NOT NULL,
                                            total_time TEXT NOT NULL,
                                            final_position INTEGER NOT NULL,
                                            race_date TEXT NOT NULL,
                                            FOREIGN KEY (driver_id) REFERENCES drivers (driver_id)
                                        );"""

    # crear una conexión de base de datos
    conn = crear_conexion(database)

    # crear tablas
    if conn is not None:
        # crear tabla drivers
        crear_tabla(conn, sql_crear_tabla_drivers)

        # crear tabla race_events
        crear_tabla(conn, sql_crear_tabla_race_events)

        # crear tabla race_statistics
        crear_tabla(conn, sql_crear_tabla_race_statistics)
    else:
        print("Error! No se pudo crear la conexión a la base de datos.")

    # cerrar la conexión
    if conn:
        conn.close()

if __name__ == '__main__':
    main()
