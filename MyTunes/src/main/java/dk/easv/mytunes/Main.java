package dk.easv.mytunes;

import dk.easv.mytunes.BLL.LogicManager;
import javafx.application.Application;
import javafx.stage.Stage;

import java.io.IOException;

public class Main extends Application {
    @Override
    public void start(Stage stage) throws IOException
    {
        new LogicManager(stage);
    }

    public static void main(String[] args)
    {
        launch();
    }
}