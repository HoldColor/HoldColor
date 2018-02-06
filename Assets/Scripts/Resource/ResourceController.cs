using System.Collections;
using System.Collections.Generic;

public class ResourceController {
    private int _playerResources;
    public int PlayerResources {
        get
        {
            return _playerResources;
        }
        set {
            _playerResources = value;
        }
    }
    private ResourceController() {
        _playerResources = 100;
    }
    private static ResourceController _instance;
    public static ResourceController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ResourceController();
            }
            return _instance;
        }
    }
}
