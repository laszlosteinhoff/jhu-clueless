# Clueless - Starter README

A repository of Unity-based  Clue-Less Game for academic purposes!

<img src="https://github.com/kevinklassen/jhu-clueless/blob/master/Game_Logo.png" width="300" height="300">

→ `Domain-specific code! Will not work on its own but can be modified for other projects.`

## Requirements

[Unity 2019.4.19f1](https://unity3d.com/unity/whats-new/2019.4.19)

## Build Tested

Visual Studio Code
* Version: 1.52.1 (system setup)
* Commit: ea3859d4ba2f3e577a159bc91e3074c5d85c0523
* Electron: 9.3.5
* Chrome: 83.0.4103.122
* Node.js: 12.14.1
* V8: 8.3.110.13-electron.0
* OS: Windows_NT x64 10.0.19042
* Memory: 1981M
* Cores: 8

## Usage

1)	Open the project in **Visual Studio Code** > and install any required extensions

2)  Game away!

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Setting up for testing

1. Install mysql on your system. https://dev.mysql.com/doc/mysql-installation-excerpt/5.7/en/
2. Connect to mysql as the root user you set up: `mysql -u root -p` (or use whatever db tool you prefer)
3. Create the clueless database: `> CREATE DATABASE clueless;`
4. Add the clueless application mysql user: `> GRANT ALL PRIVILEGES ON *.* TO 'clueless'@'localhost' IDENTIFIED BY 'Password1';`
5. Create all of the tables by running the commands from 'create_tables.sql'
6. Make sure you have python 3 and pip installed. As a bonus, I highly recommend setting up a virtual environment to install things into.
Haven't read this page so I hope it's the right thing, but it seems useful: https://packaging.python.org/guides/installing-using-pip-and-virtual-environments/
7. Install the python requirements: `pip install -r requirements.txt` (from inside the server directory)
8. If that didn't work... it's probably mysql causing the issues. You might need to install some other stuff and unfortunately I don't know what but let me know if I can help.
9. Run the server: `python3 network_service.py`
10. Make sure in the Unity 'NetworkManager' class the host is set to 'localhost:50051'
11. You should be good! Everything is running local

## License
[MIT](https://choosealicense.com/licenses/mit/)
