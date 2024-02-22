using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MoveTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BallMoves()
    {
        // Arrange
        var ball = new GameObject();
        ball.AddComponent<Rigidbody2D>().gravityScale = 0;
        ball.AddComponent<Ball>();

        // Act
        // ball should move up at the start of the game
        yield return new WaitForFixedUpdate();

        // Assert
        Assert.AreNotEqual(Vector3.zero, ball.transform.position);
    }
}
