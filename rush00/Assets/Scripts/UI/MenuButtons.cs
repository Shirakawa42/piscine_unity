using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButtons : MonoBehaviour {

    public float decalage = 2f;

    [SerializeField] private Animator[] layers;

    [System.Serializable]
    public class MyEventType : UnityEvent {}

    public MyEventType OnValidSelection;

    private bool is_selected = false;
    private float last_update = 0;
    private int next_layer_to_update = 0;

	// Use this for initialization
	void Start () {
        SetIsMovingOnAnimator(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (!is_selected)
            return;
        if (next_layer_to_update >= layers.Length)
            return;

        if (Time.time - last_update > decalage) {
            last_update = Time.time;
            SetIsMovingOnAnimator(next_layer_to_update, true);
            next_layer_to_update++;
        }
	}

    public void SetIsSelected(bool selected) {
        is_selected = selected;
        last_update = 0;
        next_layer_to_update = 0;

        if (!selected)
            SetIsMovingOnAnimator(false);
    }

    public void ValidSelection() {
        OnValidSelection.Invoke();
    }

    private void SetIsMovingOnAnimator(bool move) {
        for (int i = 0; i < layers.Length; i++) {
            SetIsMovingOnAnimator(i, move);
        }
    }

    private void SetIsMovingOnAnimator(int layer, bool move) {
        layers[layer].SetBool("is_moving", move);
    }

}
