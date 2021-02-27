class rooms():

    def study(self):
        print('Study')

    def hall(self):
        print('Hall')

    def lounge(self):
        print('Lounge') 

    def dining(self):
        print('Dining Room')

    def kitchen(self):
        print('Kitchen')

    def ballroom(self):
        print('Ballroom')

    def conservatory(self):
        print('Conservatory')

    def library(self):
        print('Library')

    def billiard(self):
        print('Billiard Room')

class hallways():

    def study_hall(self):
        print('Study-Hall Hallway')

    def study_library(self):
        print('Study-Library Hallway')
   
    def hall_billiard(self):
        print('Hall-Billiard Hallway')
 
    def hall_lounge(self):
        print('Hall-Lounge Hallway')

    def lounge_dining(self):
        print('Lounge-Dining Hallway') 

    def dining_billiard(self):
        print('Dining-Billiard Hallway')

    def dining_kitchen(self):
        print('Dining-Kitchen Hallway')

    def kitchen_ballroom(self):
        print('Kitchen-Ballroom Hallway')

    def ballroom_billiard(self):
        print('Ballroom-Billiard Hallway')

    def ballroom_conservatory(self):
        print('Ballroom-Conservatory Hallway')

    def conservatory_library(self):
        print('Conservatory-Library Hallway')

class passages():

    def study_billiard(self):
        print('Study-Billiard Secret Passage')

    def lounge_billiard(self):
        print('Lounge-Billiard Secret Passage')

    def kitchen_billiard(self):
        print('Kitchen-Billiard Secret Passage')

    def conservatory_billiard(self):
        print('Conservatory-Billiard Secret Passage')

class players():

    def player_one(self):
        print('Miss Scarlet')

    def player_two(self):
        print('Col. Mustard')

    def player_three(self):
        print('Mrs. White')    

    def player_four(self):
        print('Mr. Green')

    def player_five(self):
        print('Mrs. Peacock')

    def player_six(self):
        print('Prof. Plum')

#---------------------Adjacency List-----------------------------------------

# layout = {
#     rooms.study(): set([rooms.hall(), rooms.library(), rooms.billiard()]),
#     rooms.library(): set([rooms.study(), rooms.billiard(), rooms.conservatory()]),
#     rooms.conservatory(): set([rooms.library(), rooms.ballroom(), rooms.billiard()]),
#     rooms.ballroom(): set([rooms.conservatory(), rooms.billiard(), rooms.kitchen()]),
#     rooms.kitchen(): set([rooms.ballroom(), rooms.dining(), rooms.billiard()]),
#     rooms.dining(): set([rooms.kitchen(), rooms.billiard(), rooms.lounge()]),
#     rooms.lounge(): set([rooms.dining(), rooms.hall(), rooms.billiard()]),
#     rooms.hall(): set([rooms.lounge(), rooms.billiard(), rooms.study()])
#     }

layout = {
    'study': set(['hall', 'library', 'billiard']),
    'library': set(['study', 'billiard', 'conservatory']),
    'conservatory': set(['library', 'ballroom', 'billiard']),
    'ballroom': set(['conservatory', 'billiard', 'kitchen']),
    'kitchen': set(['ballroom', 'dining', 'billiard']),
    'dining': set(['kitchen', 'billiard', 'lounge']),
    'lounge': set(['dining', 'hall', 'billiard']),
    'hall': set(['lounge', 'billiard', 'study'])
    }

if __name__ == "__main__":
    print(layout['study'])