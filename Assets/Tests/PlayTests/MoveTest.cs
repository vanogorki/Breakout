using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MoveTest
{
    [SetUp]
    public void Setup()
    {
        var camera = GameObject.Instantiate(new GameObject().AddComponent<Camera>());
        camera.tag = "MainCamera";
    }
    
    [UnityTest]
    public IEnumerator BallMoves()
    {
        // Arrange
        var ball = new GameObject();
        ball.AddComponent<Rigidbody2D>().gravityScale = 0;
        ball.AddComponent<Ball>();

        // Act
        // ball should move up as soon as it's created
        yield return new WaitForFixedUpdate();

        // Assert
        Assert.AreNotEqual(Vector3.zero, ball.transform.position);
    }
}
