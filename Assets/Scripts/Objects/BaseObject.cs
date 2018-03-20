using UnityEngine;

public class BaseObject : ScriptableObject {
    protected int hauteur;
    protected int level;

    public BaseObject(int hauteur, int level) {
        this.hauteur = hauteur;
        this.level = level;
    }
}