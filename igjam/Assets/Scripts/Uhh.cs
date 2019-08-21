using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uhh : MonoBehaviour {

    // INPUT STUFF 
    public static Vector2 InputDirection () {
        Vector2 v = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        if (v.magnitude > 1f) v = v.normalized;
        return v;
    }
    public static Vector2 MousePosition () { return Camera.main.ScreenToWorldPoint (Input.mousePosition); }
    // public static void ClearInput ( ) {
    //     for (int i = 0; i < 5; i++) {
    //         Rewired.Player p = Rewired.ReInput.players.GetPlayer (i);
    //         p.ClearInputEventDelegates ( );
    //     }
    // }

    // COLOR SHIT  
    public static float ColorIntensity (Color c) { return c.r * .299f + c.g * 0.587f + c.b * 0.114f; }
    public static Color Invert (Color c) { return new Color (1f - c.r, 1f - c.g, 1f - c.b); }
    public static Color BackgroundColor () { return Camera.main.backgroundColor; }
    public static Color RandomColor (float saturation = 0.7f) {
        Color c = Color.HSVToRGB (Random.Range (0f, 1f), saturation, 1f);
        c *= 1.5f - ColorIntensity (c);
        c.a = 1f;
        return c;
    }

    // MATH SHIT 
    public static int RandomLookdir () { if (Uhh.Chance (50f)) return 1; return -1; }
    public static float RandomSine () { return -10000f + Random.Range (0f, 360f); }
    public static float AngleFromVector (Vector2 dir) { return (Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg + 270f) % 360f; }
    public static Vector2 VectorFromAngle (float ang) { ang += 90f; ang = ang % 360f; ang *= Mathf.Deg2Rad; return new Vector2 (Mathf.Cos (ang), Mathf.Sin (ang)); }
    public static Vector2 RotationFrom (Transform t) { float ang = t.eulerAngles.z; ang += 90f; ang *= Mathf.Deg2Rad; return new Vector2 (Mathf.Cos (ang), Mathf.Sin (ang)); }
    public static Quaternion Rotation (Vector2 dir) { return Quaternion.Euler (0, 0, AngleFromVector (dir)); }
    public static Quaternion RotatedQuaternion (Vector2 dir, float angle) { return Quaternion.Euler (0, 0, AngleFromVector (dir) + angle); }
    public static Vector2 RotatedVector (Vector2 dir, float angle) { return Quaternion.Euler (0, 0, AngleFromVector (dir) + angle) * Vector2.up * dir.magnitude; }
    public static Vector3 Direction (Vector2 d) { return d * 0.02f; }
    public static Vector2 Mirror (Vector2 dir, Vector2 norm) { return Vector2.Reflect (dir, norm); }
    public static Vector2 Perp (Vector2 v) { return new Vector2 (-v.y, v.x); }
    public static Vector2 SineVector (float t) { return new Vector2 (Mathf.Sin (t), Mathf.Cos (t)); }
    public static Vector2 RandomDirection () {
        int r = Random.Range (0, 4);
        if (r == 0) return Vector2.right;
        if (r == 1) return Vector2.up;
        if (r == 2) return Vector2.down;
        return Vector2.left;
    }
    public static bool Incoming (Vector2 dir, Vector2 normal) {
        return Vector2.Dot (dir, normal) > 0;
    }
    public static Vector2 RandomVector (float magnitude = 1f) { return VectorFromAngle (Random.Range (0f, 360f)) * magnitude; }
    // in lack of a better name ... basically half reflection
    public static Vector2 Thump (Vector2 dir, Vector2 norm) {
        // removes normal from dir. for example, if norm is down, leaves only left, right and up in dir.
        return dir - norm * Vector2.Dot (dir, norm);
    }
    public static Vector2 Project (Vector2 v, Vector2 unto) {
        return unto.normalized * Vector2.Dot (v, unto);
    }
    public static float Cross (Vector2 a, Vector2 b) { return a.x * b.y - a.y * b.x; }
    public static bool IsZero (float f) { return Mathf.Abs (f) < 0.000001f; }
    public static bool Intersects (Vector2 p1, Vector2 p2, Vector2 p3, Vector3 p4, out Vector2 intersection) {
        intersection = Vector2.zero;
        var d = (p2.x - p1.x) * (p4.y - p3.y) - (p2.y - p1.y) * (p4.x - p3.x);
        if (d == 0.0f) { return false; }
        var u = ((p3.x - p1.x) * (p4.y - p3.y) - (p3.y - p1.y) * (p4.x - p3.x)) / d;
        var v = ((p3.x - p1.x) * (p2.y - p1.y) - (p3.y - p1.y) * (p2.x - p1.x)) / d;
        if (u < 0.0f || u > 1.0f || v < 0.0f || v > 1.0f) { return false; }
        intersection.x = p1.x + u * (p2.x - p1.x);
        intersection.y = p1.y + u * (p2.y - p1.y);
        return true;
    }

    public static List<int> RandomNumbersBetween (int n, int min, int max) {
        List<int> nums = new List<int> ();
        for (int i = min; i < max; i++) {
            nums.Add (i);
        }
        int nn = nums.Count - n;
        for (int i = 0; i < nn; i++) {
            nums.RemoveAt (Random.Range (0, nums.Count));
        }
        return nums;
    }

    public static Vector2 LongestVector (params Vector2[] vectors) {
        Vector2 v = Vector2.zero;
        float mag = 0;
        for (int i = 0; i < vectors.Length; i++) {
            float m = vectors[i].magnitude;
            if (m > mag) {
                mag = m;
                v = vectors[i];
            }
        }
        return v;
    }

    // CAMERA SHIT 
    public static float ScreenRatio () { return (float) Screen.width / (float) Screen.height; }
    public static bool Onscreen (Vector2 pos, float radius = 0) { return !Offscreen (pos, radius); }
    public static bool Offscreen (Vector2 pos, float radius = 0) {
        Vector2 campos = Camera.main.transform.position;
        if (Mathf.Abs (radius) > 0) pos += (campos - pos).normalized * radius;
        if (DirToScreenFrom (pos).sqrMagnitude > 0.0001f)
            return true;
        return false;
    }
    public static Vector2 DirToScreenFrom (Vector2 position, Vector2 size) {
        return Uhh.LongestVector (
            DirToScreenFrom (position + new Vector2 (size.x, size.y) * .5f),
            DirToScreenFrom (position + new Vector2 (-size.x, size.y) * .5f),
            DirToScreenFrom (position + new Vector2 (size.x, -size.y) * .5f),
            DirToScreenFrom (position + new Vector2 (-size.x, -size.y) * .5f));
    }
    public static Vector2 DirToScreenFrom (Vector2 pos) {
        Vector2 vp = Camera.main.WorldToViewportPoint (pos);
        Vector2 d = Vector2.zero;

        if (vp.x < 0) d.x = -vp.x;
        if (vp.x > 1) d.x = -vp.x + 1f;
        if (vp.y < 0) d.y = -vp.y;
        if (vp.y > 1) d.y = -vp.y + 1f;

        if (d.sqrMagnitude > 0) {
            float screenratioY = Camera.main.orthographicSize * 2f;
            float screenratioX = screenratioY * ScreenRatio ();
            d.x *= screenratioX;
            d.y *= screenratioY;
        }

        return d;
    }
    public static Vector2 ScreenPos (float x, float y) {
        Vector2 campos = Camera.main.transform.position;
        float o = Camera.main.orthographicSize;
        float r = (float) Screen.width / (float) Screen.height;
        return campos + new Vector2 (o * r * x, o * y);
    }
    public static Vector2 ScreenTopLeft () { return ScreenPos (-1, 1); }
    public static Vector2 ScreenTopRight () { return ScreenPos (1, 1); }
    public static Vector2 ScreenBottomLeft () { return ScreenPos (-1, -1); }
    public static Vector2 ScreenBottomRight () { return ScreenPos (1, -1); }

    // OTHER SHIT 
    public static void ReloadLevel () {
        LoadLevel (SceneManager.GetActiveScene ().name);
    }
    // public static void LoadLevel (LevelSettings level) {
    //     foreach (Player p in FindObjectsOfType<Player> ( )) {
    //         God.Kill (p);
    //     }
    //     LevelScriptBase.difficulty = level.difficulty;
    //     SceneManager.LoadScene (level.name);
    // }
    public static void LoadLevel (string name) {
        // foreach (Player p in FindObjectsOfType<Player> ( )) {
        //     God.Kill (p);
        // }
        SceneManager.LoadScene (name);
    }
    public static bool IsLetter (char c) {
        if (c >= 'a' && c <= 'z') return true;
        return false;
    }
    public static bool Chance (float chance) {
        return Random.Range (0f, 100f) < chance;
    }
    public static bool Like (float chance) {
        return Random.Range (0f, 100f) < chance;
    }
}