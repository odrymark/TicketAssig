module dk.easv.mytunes {
    requires javafx.controls;
    requires javafx.fxml;
    requires javafx.media;


    exports dk.easv.mytunes;
    opens dk.easv.mytunes to javafx.fxml;
    exports dk.easv.mytunes.PL.controllers;
    opens dk.easv.mytunes.PL.controllers to javafx.fxml;
}