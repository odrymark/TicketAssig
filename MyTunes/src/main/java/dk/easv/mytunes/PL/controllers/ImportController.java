package dk.easv.mytunes.PL.controllers;

import dk.easv.mytunes.BLL.LogicManager;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class ImportController
{
    private LogicManager logicManager;
    @FXML
    private TextField title;
    @FXML
    private TextField artist;
    @FXML
    private TextField path;
    @FXML
    private ComboBox<String> genre;
    @FXML
    private Label titleText;
    @FXML
    private Label artistText;
    @FXML
    private Label pathText;
    @FXML
    private Label genreText;
    private ObservableList<String> items = FXCollections.observableArrayList("Pop", "Rock", "Classical", "Jazz", "Hip-Hop", "Country", "Electronic", "Other");

    public ImportController(LogicManager logicManager)
    {
        this.logicManager = logicManager;
    }

    @FXML
    private void initialize()
    {
        genre.setItems(items);
    }

    @FXML
    private void importSong()
    {
        if(!title.getText().isEmpty() && !artist.getText().isEmpty() && genre.getValue() != null && !path.getText().isEmpty())
        {
            logicManager.addSong(title.getText() + " " + artist.getText() + " " + genre.getValue() + " " + path.getText().replace('\\', '/'));
            Stage stage = (Stage) title.getScene().getWindow();
            stage.close();
        }
        else
        {
            if(title.getText().isEmpty())
            {
                titleText.setStyle("-fx-text-fill: red");
            }
            else
            {
                titleText.setStyle("-fx-text-fill: black");
            }

            if(artist.getText().isEmpty())
            {
                artistText.setStyle("-fx-text-fill: red");
            }
            else
            {
                artistText.setStyle("-fx-text-fill: black");
            }

            if(path.getText().isEmpty())
            {
                pathText.setStyle("-fx-text-fill: red");
            }
            else
            {
                pathText.setStyle("-fx-text-fill: black");
            }

            if(genre.getValue() == null)
            {
                genreText.setStyle("-fx-text-fill: red");
            }
            else
            {
                genreText.setStyle("-fx-text-fill: black");
            }
        }
    }
}
