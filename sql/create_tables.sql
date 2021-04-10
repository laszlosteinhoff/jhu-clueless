USE clueless;

DROP TABLE IF EXISTS move;
DROP TABLE IF EXISTS player_card;
DROP TABLE IF EXISTS player;
DROP TABLE IF EXISTS game;
DROP TABLE IF EXISTS card;
DROP TABLE IF EXISTS account;

CREATE TABLE IF NOT EXISTS account(
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(40) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS card(
    id INT NOT NULL,
    card_type ENUM('weapon', 'suspect', 'room') NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS game(
    id INT NOT NULL AUTO_INCREMENT,
    status ENUM('created', 'started', 'completed') NOT NULL,
    weapon_id INT NOT NULL,
    suspect_id INT NOT NULL,
    room_id INT NOT NULL,
    FOREIGN KEY (suspect_id) REFERENCES card(id),
    FOREIGN KEY (weapon_id) REFERENCES card(id),
    FOREIGN KEY (room_id) REFERENCES card(id),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS player(
    id INT NOT NULL AUTO_INCREMENT,
    account_id INT NOT NULL,
    game_id INT NOT NULL,
    number INT NOT NULL,
    name VARCHAR(40) NOT NULL,
    FOREIGN KEY (account_id) REFERENCES account(id),
    FOREIGN KEY (game_id) REFERENCES game(id),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS player_card(
    player_id INT NOT NULL,
    card_id INT NOT NULL,
    FOREIGN KEY (player_id) REFERENCES player(id),
    FOREIGN KEY (card_id) REFERENCES card(id)
);

CREATE TABLE IF NOT EXISTS move(
    id INT NOT NULL AUTO_INCREMENT,
    player_id INT NOT NULL,
    number INT NOT NULL,
    location INT NOT NULL,
    weapon_id INT NOT NULL,
    suspect_id INT NOT NULL,
    room_id INT NOT NULL,
    FOREIGN KEY (weapon_id) REFERENCES card(id),
    FOREIGN KEY (suspect_id) REFERENCES card(id),
    FOREIGN KEY (room_id) REFERENCES card(id),
    PRIMARY KEY (id)
);