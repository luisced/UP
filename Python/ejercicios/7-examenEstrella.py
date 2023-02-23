musica = {
    'The Black Keys': {
        'El Camino': {
            'Lonely Boy': {
                'liked': False,
                'reproducciones': '397810130',
                'duracion_ms': 187800,
                'tags': ('Rock', 'Catchy Tunes')
            },
            'Little Black Submarines': {
                'liked': True,
                'reproducciones': '89206240',
                'duracion_ms': 246600,
                'tags': ('Rock & Roll', 'Classics', 'Blues', 'Ballad',
                         'Rock', 'Ballad', 'Blues', 'Classics', 'Classics',
                         'Ballad', 'Rock & Roll', 'Classics', 'Blues',
                         'Rock & Roll', 'Classics', 'Rock & Roll', 'Blues')
            },
            'Hell of a Season': {
                'liked': True,
                'reproducciones': 10425570,
                'duracion_ms': 207000,
                'tags': ('Rock')
            }
        }
    },
    'Greta Van Fleet': {
        'From the Fires': {
            'Safari Song': {
                'liked': True,
                'reproducciones': 104450524,
                'duracion_ms': '212400',
                'tags': ('Rock', 'Classics')
            },
            'Edge of Darkness': {
                'liked': False,
                'reproducciones': '47756093',
                'duracion_ms': 256800,
                'tags': ('Rock')
            },
            'Highway Tune': {
                'liked': True,
                'reproducciones': '181238080',
                'duracion_ms': 180000,
                'tags': ('Hard Rock')
            },
            'Black Smoke Rising': {
                'liked': True,
                'reproducciones': 119129373,
                'duracion_ms': 251400,
                'tags': ('Rock', 'Classics')
            }
        },
        'The Battle at Gardens Gate': {
            'Heat Above': {
                'liked': True,
                'reproducciones': 67071430,
                'duracion_ms': 324600,
                'tags': ('Rock', 'Ballad')
            },
            'Age of Machine': {
                'liked': False,
                'reproducciones': '23667326',
                'duracion_ms': 391800,
                'tags': ('Rock')
            },
            'Stardust Chords': {
                'liked': False,
                'reproducciones': 16001476,
                'duracion_ms': 274200,
                'tags': ('Ballad')
            },
        },
    },
    'Stromae': {
        'Racine Carree': {
            'Ta Fete': {
                'liked': False,
                'reproducciones': 75156132,
                'duracion_ms': '153000',
                'tags': ('French Pop', 'Electro')
            },
            'Tous le Memes': {
                'liked': True,
                'reproducciones': 194588900,
                'duracion_ms': 198000,
                'tags': ('French Pop', 'Electro')
            },
            'Ave Cesaria': {
                'liked': True,
                'reproducciones': '50747834',
                'duracion_ms': 245400,
                'tags': ('French Pop', 'Electro', 'Ethnic')
            }
        },
        'Multitude': {
            'Invaincu': {
                'liked': True,
                'reproducciones': '16732216',
                'duracion_ms': 123000,
                'tags': ('French Pop', 'Electro')
            },
            'Sante': {
                'liked': True,
                'reproducciones': '92011201',
                'duracion_ms': '186600',
                'tags': ('Ethnic')
            },
            'Fils de Joie': {
                'liked': False,
                'reproducciones': '34948659',
                'duracion_ms': 189000,
                'tags': ('French Pop')
            },
        },
    },
}


def getAttributeFromSong(Band, Album, Song, Attribute):
    """Returns the value of the attribute of a song.

    Args:
        song (dict): A dictionary with the song information.
        attribute (str): The attribute to get.

    Returns:
        The value of the attribute.
    """
    return musica[Band][Album][Song][Attribute]


# 1--- Imprimir el numero de reproducciones de la cancion "Highway Tune"
print(getAttributeFromSong('Greta Van Fleet',
      'From the Fires', 'Highway Tune', 'reproducciones'))

# 2--- Imprimir el numero de reproducciones de la cancion "Heat Above"

print(getAttributeFromSong('Greta Van Fleet',
      'The Battle at Gardens Gate', 'Heat Above', 'reproducciones'))


# 3--- Imprimir el numero de reproducciones de la cancion "Sante"
print(getAttributeFromSong('Stromae', 'Multitude', 'Sante', 'reproducciones'))

# 4--- Imprimir el numero de reproducciones de la cancion "Lonely Boy"
print(getAttributeFromSong('The Black Keys',
      'El Camino', 'Lonely Boy', 'reproducciones'))

# 5--- Imprimir la duracion de la cancion "Little Black Submarines"
print(getAttributeFromSong('The Black Keys', 'El Camino',
      'Little Black Submarines', 'duracion_ms'))

# 6--- Obtener la duracion total del disco "Multitude"
multitudeDuracionTotal = 0
for cancion in musica['Stromae']['Multitude']:
    multitudeDuracionTotal += int(getAttributeFromSong('Stromae',
                                  'Multitude', cancion, 'duracion_ms'))
print(multitudeDuracionTotal)

# 7--- Obtener el promedio de reproducciones del disco "The Battle at Gardens Gate"

reproducciones = 0
for cancion in musica['Greta Van Fleet']['The Battle at Gardens Gate']:
    reproducciones += int(getAttributeFromSong('Greta Van Fleet',
                          'The Battle at Gardens Gate', cancion, 'reproducciones'))
print(reproducciones/len(musica['Greta Van Fleet']
      ['The Battle at Gardens Gate']))

# 8--- Obtener el numero de discos de The Black Keys y de Greta Van Fleet. Determinar quien tiene mas discos

numDiscos1 = len(musica['The Black Keys'])
numDiscos2 = len(musica['Greta Van Fleet'])
if numDiscos1 > numDiscos2:
    print('The Black Keys tiene mas discos')
elif numDiscos1 < numDiscos2:
    print('Greta Van Fleet tiene mas discos')
else:
    print('Tienen la misma cantidad de discos')


# 9--- Sustituir los tags de la cancion 'Little Black Submarines' por una tupla que contenga
#     los valores unicos de la estructura original. Es decir, eliminar duplicados

tags = musica['The Black Keys']['El Camino']['Little Black Submarines']['tags']
tags = tuple(set(tags))
musica['The Black Keys']['El Camino']['Little Black Submarines']['tags'] = tags
print(musica['The Black Keys']['El Camino']['Little Black Submarines']['tags'])


# 10--- Obtener la duracion promedio de las canciones del disco "Racine Carree"
duracionPromedio = 0
for cancion in musica['Stromae']['Racine Carree']:
    duracionPromedio += int(getAttributeFromSong('Stromae',
                            'Racine Carree', cancion, 'duracion_ms')) / 1000
print(duracionPromedio/len(musica['Stromae']['Racine Carree']))

# 11--- Imprimir el nombre del disco con mas reproducciones de Greta Van Fleet
# hacer lo mismo con likes
maxReproducciones = 0
maxLikes = 0
for album in musica['Greta Van Fleet']:
    reproducciones = 0
    likes = 0
    for cancion in musica['Greta Van Fleet'][album]:
        reproducciones += int(getAttributeFromSong('Greta Van Fleet',
                              album, cancion, 'reproducciones'))
        if getAttributeFromSong('Greta Van Fleet', album, cancion, 'liked'):
            likes += 1
    if reproducciones > maxReproducciones:
        maxReproducciones = reproducciones
        albumReproducciones = album
    if likes > maxLikes:
        maxLikes = likes
        albumLikes = album
print(albumReproducciones, albumLikes)

# 13--- Agregar la cancion "Tiene Espinas el Rosal" al disco "El Camino". La informacion de dicha cancion es la siguiente:

'''
'liked':True,
'reproducciones':'92011201',
'duracion_ms':'186600',
'tags':('Cumbion bien loco', 'Lo mejor para tus bodas')
'''

musica['The Black Keys']['El Camino']['Tiene Espinas el Rosal'] = {
    'liked': True,
    'reproducciones': '92011201',
    'duracion_ms': '186600',
    'tags': ('Cumbion bien loco', 'Lo mejor para tus bodas')
}
print(musica['The Black Keys']['El Camino']['Tiene Espinas el Rosal'])

# 14--- Determinar cual es el disco con mas likes de todos
maxLikes = 0
for banda in musica:
    for album in musica[banda]:
        likes = 0
        for cancion in musica[banda][album]:
            if getAttributeFromSong(banda, album, cancion, 'liked'):
                likes += 1
        if likes > maxLikes:
            maxLikes = likes
            albumLikes = album
            bandaLikes = banda
print(bandaLikes, albumLikes)

# 15--- Determinar cual es el disco con mayor duracion de todos
maxDuracion = 0
for banda in musica:
    for album in musica[banda]:
        duracion = 0
        for cancion in musica[banda][album]:
            duracion += int(getAttributeFromSong(banda,
                            album, cancion, 'duracion_ms'))
        if duracion > maxDuracion:
            maxDuracion = duracion
            albumDuracion = album
            bandaDuracion = banda
print(bandaDuracion, albumDuracion)

# 16--- Via consola, mostrar al usuario el nombre de los discos de  Greta Van Fleet. Pedirle al usuario que seleccione uno
#      una vez seleccionado, mostrar las canciones que lo componen. Pedir al usuario que seleccione una.
#      una vez seleccionada, preguntarle al usuario si le gustaria agregar un tag a la cancion. Si dice que si, determinar si el
#      tag ya estaba presente en los tags. Si no estaba, agregarlo. Si ya estaba, imprimir "Hijole joven, no se va a poder"
#      imprimir la estructura resultante


def askUser(question):
    return input(question + ' ')


def printAlbums(banda):
    print('Discos de ' + banda + ':')
    for i, album in enumerate(musica[banda]):
        print(str(i + 1) + '. ' + album)


def printSongs(banda, album):
    print('Canciones de ' + album + ':')
    for i, cancion in enumerate(musica[banda][album]):
        print(str(i + 1) + '. ' + cancion)


def printTags(banda, album, cancion):
    print('Tags de ' + cancion + ':')
    for i, tag in enumerate(musica[banda][album][cancion]['tags']):
        print(str(i + 1) + '. ' + tag)


def addTag(banda, album, cancion, tag):
    tags = musica[banda][album][cancion]['tags']
    if tag not in tags:
        musica[banda][album][cancion]['tags'] = tags + (tag, )
        print('Tag agregado')
    else:
        print('Hijole joven, no se va a poder')


printAlbums('Greta Van Fleet')
album = askUser('Seleccione un disco')
printSongs('Greta Van Fleet', album)
cancion = askUser('Seleccione una cancion')
printTags('Greta Van Fleet', album, cancion)
tag = askUser('Desea agregar un tag?')
if tag == 'si':
    tag = askUser('Ingrese el tag')
    addTag('Greta Van Fleet', album, cancion, tag)
print(musica['Greta Van Fleet'][album][cancion])


# EXTRA --- Estos no son a fuerza, pero si quieren un desafio y puntos extra valdria la pena intentarlo
# A--- Obtener el promedio de reproducciones del disco "The Battle at Gardens Gate" usando Ciclos For
# B--- Obtener la duracion total del disco "Multitude" usando Ciclos For
# C--- Crear e imprimir una lista con los nombres de los Discos de Stroma usando List Comprehension
