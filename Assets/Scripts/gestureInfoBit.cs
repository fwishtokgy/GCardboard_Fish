using System.Collections;
using System.Collections.Generic;

struct gestureInfoBit {

    private float _degree;
    private float _time;
    private Gestate _state;

    public gestureInfoBit(float degreeAtCapture, float timeAtCapture, Gestate stateAtCapture)
    {
        _degree = degreeAtCapture;
        _time = timeAtCapture;
        _state = stateAtCapture;
    }
    public void setInfo(float degreeAtCapture,float timeAtCapture, Gestate stateAtCapture)
    {
        _degree = degreeAtCapture;
        _time = timeAtCapture;
        _state = stateAtCapture;
    }
    public float degree()
    {
        return _degree;
    }
    public float time()
    {
        return _time;
    }
    public Gestate state()
    {
        return _state;
    }
}
