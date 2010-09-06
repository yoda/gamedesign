      _______ __________________ _______     ___  _______    ___  _______ 
     (  ____ \\__   __/\__   __/(  ____ \   /   )/ ___   )  /   )/ ___   )
     | (    \/   ) (      ) (   | (    \/  / /) |\/   )  | / /) |\/   )  |
     | |         | |      | |   | (_____  / (_) (_   /   )/ (_) (_   /   )
     | |         | |      | |   (_____  )(____   _)_/   /(____   _)_/   / 
     | |         | |      | |         ) |     ) ( /   _/      ) ( /   _/  
     | (____/\___) (___   | |   /\____) |     | |(   (__/\    | |(   (__/\
     (_______/\_______/   )_(   \_______)     (_)\_______/    (_)\_______/
                                                                          
         _______  _______  _______ _________ _______  _______ _________
        (  ____ )(  ____ )(  ___  )\__    _/(  ____ \(  ____ \\__   __/
        | (    )|| (    )|| (   ) |   )  (  | (    \/| (    \/   ) (   
        | (____)|| (____)|| |   | |   |  |  | (__    | |         | |   
        |  _____)|     __)| |   | |   |  |  |  __)   | |         | |   
        | (      | (\ (   | |   | |   |  |  | (      | |         | |   
        | )      | ) \ \__| (___) ||\_)  )  | (____/\| (____/\   | |   
        |/       |/   \__/(_______)(____/   (_______/(_______/   )_(   
                                                                       

------------
Git Tips
------------

Under windows use:
Msys Git from google code.
Install a gui mergetool - http://diffuse.sourceforge.net/download.html

Under Osx:
Opendiff is a nice mergetool


#### After you have completed some work and you want to add it to the repositry:
----------
git add "files you modified" <br /> 
git commit -m "message" <br />
git push origin "branch" <br />

#### If there is a conflict make sure you have pulled:
-----------
git pull origin master

If it wont let you pull make sure you have commited your changes

#### If there is a conflict that cannot be fixed without intervention:
-------------------
git mergetool -t diffuse


