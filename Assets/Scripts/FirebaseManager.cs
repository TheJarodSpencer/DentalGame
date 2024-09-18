using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Firestore;

public class FirebaseManager : MonoBehaviour
{ 
    void Start()
    {
        Debug.Log("Firebase Firestore is initialized via JavaScript in WebGL.");
        TestFirestore();
    }

    void TestFirestore()
    {
        // Here you would add or modify interaction with Firestore if needed,
        // but it would have to be handled through JavaScript in WebGL
        // This is just a placeholder for interaction via JS
        Debug.Log("Testing Firestore in WebGL. Interaction through JavaScript is required.");
    }

}   
    /*
    private FirebaseFirestore firestore;
    // Start is called before the first frame update
    void Start()
    {
        InitializeFirebase();
    }

    void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                firestore = FirebaseFirestore.DefaultInstance;
                Debug.Log("Firestore initialized successfully.");
                TestFirestore();
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
            }
        });
    }

    void TestFirestore()
    {
        // Add data to Firestore
        AddData("users", "user1", new Dictionary<string, object>
        {
            { "name", "John Doe" },
            { "email", "john.doe@example.com" }
        });

        // Read data from Firestore
        ReadData("users", "user1");
    }

    void AddData(string collectionName, string documentId, Dictionary<string, object> data)
    {
        DocumentReference docRef = firestore.Collection(collectionName).Document(documentId);
        docRef.SetAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Document successfully written!");
            }
            else
            {
                Debug.LogError("Error writing document: " + task.Exception);
            }
        });
    }

    void ReadData(string collectionName, string documentId)
    {
        DocumentReference docRef = firestore.Collection(collectionName).Document(documentId);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    Debug.Log("Document data: " + snapshot.GetValue<string>("name") + ", " + snapshot.GetValue<string>("email"));
                }
                else
                {
                    Debug.Log("No such document!");
                }
            }
            else
            {
                Debug.LogError("Error getting document: " + task.Exception);
            }
        });
    }
}
*/