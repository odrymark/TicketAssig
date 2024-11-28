package dk.easv.mytunes.PL.controllers;

import dk.easv.mytunes.BLL.LogicManager;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.control.Slider;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;
import javafx.util.Duration;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class TunesController
{
    private LogicManager logicManager;
    private List<String> songPaths = new ArrayList<>();
    @FXML
    private ListView<String> songsList;
    private ObservableList<String> songs = FXCollections.observableArrayList();
    @FXML
    private Button playBtn;
    private boolean isPlaying = false;
    private MediaPlayer mediaPlayer;
    private int songPlayingIdx;
    @FXML
    private Slider volumeSlider;

    public TunesController(LogicManager logicManager)
    {
        this.logicManager = logicManager;
    }

    @FXML
    private void initialize()
    {
        songsList.setItems(songs);
        volumeSlider.setValue(50);
    }

    @FXML
    private void importSng() throws IOException
    {
        logicManager.importWindow();
    }

    @FXML
    private void playStopSong()
    {
        if(isPlaying)
        {
            mediaPlayer.pause();
            playBtn.setText("Play");
            isPlaying = false;
        }
        else if((songsList.getSelectionModel().getSelectedItems().getFirst() != null && mediaPlayer == null) || songPlayingIdx != songsList.getSelectionModel().getSelectedIndex())
        {
            songPlayingIdx = songsList.getSelectionModel().getSelectedIndex();

            File file = new File(songPaths.get(songPlayingIdx));
            Media media = new Media(file.toURI().toString());
            mediaPlayer = new MediaPlayer(media);
            mediaPlayer.setOnEndOfMedia(() -> {mediaPlayer.seek(Duration.seconds(0)); mediaPlayer.pause();  isPlaying = false; playBtn.setText("Play");});
            mediaPlayer.setVolume(volumeSlider.getValue() / 100);
            mediaPlayer.play();
            playBtn.setText("Stop");
            isPlaying = true;
        }
        else if(!isPlaying)
        {
            mediaPlayer.play();
            playBtn.setText("Stop");
            isPlaying = true;
        }
    }

    @FXML
    private void changeVolume()
    {
        mediaPlayer.setVolume(volumeSlider.getValue() / 100);
    }

    @FXML
    private void nextSong()
    {

    }

    @FXML
    private void prevSong()
    {

    }

    public void addSong(String details)
    {
        String[] split = details.split(" ");
        songPaths.add(split[3]);

        songs.add(split[0] + " " + split[1] + " " + split[2]);
    }
}