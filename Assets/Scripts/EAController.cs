using easyar;

public class EAController
{
    public EAController(ImageTargetController imagecontroller,PathType PathType,string path,ImageTrackerFrameFilter filter)
    {
        imagecontroller.ImageFileSource.PathType= PathType;
        imagecontroller.ImageFileSource.Path = path;
        imagecontroller.ImageFileSource.Scale = 100;
        imagecontroller.Tracker = filter;
    }
}