using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
	public bool displayGridGizmos;
	public LayerMask unwalkableMask; // The unwalkable part of the map. This is declared by assigning the "unwalkable" layer type to a game object with 2D collision
	public Vector3 gridWorldSize; // The size of the map. Assign this in the inspector on the game object with this script on it
	public Vector3 worldBottomLeft; // The bottom left of the gridWorldSize
	public float nodeRadius; // The size of each node. I found that 0.03 works the best for this game so far
	Node[,] grid; // Holds size of the grid across and down (800 by 800 in the case of the tutorial map)

	float nodeDiameter; // Diameter of whatever node is being worked on by the code at the moment
	int gridSizeX, gridSizeY; // Hold total number of nodes along the X and Y axes

	void Awake()
	{
		nodeDiameter = nodeRadius * 2; // Gets diameter of the nodes that will be used
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter); // Gets total number of nodes along the X axis
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter); // Gets total number of nodes along the Y axis
		CreateGrid(); // Calls the CreateGrid method to begin creating the grid
	}

	public int MaxSize
	{
		get
		{
			return gridSizeX * gridSizeY;
		}
	}

	// Creates the grid
	public void CreateGrid()
	{
		grid = new Node[gridSizeX, gridSizeY]; // Sets the total size of the grid
		worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2; // Math for finding the bottom left of the gridWorldSize

		// This is what sets up the grid with your walkable and nonwalkable grid squares
		for (int x = 0; x < gridSizeX; x ++)
		{
			for (int y = 0; y < gridSizeY; y ++)
			{
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask));
				grid[x,y] = new Node(walkable, worldPoint, x, y);
			}
		}
	}

	public List<Node> GetNeighbors(Node node)
	{
		List<Node> neighbors = new List<Node>();

		for (int x = -1; x <= 1; x++)
		{
			for(int y = -1; y <= 1; y++)
			{
				if (x == 0 && y == 0)
				{
					continue;
				}

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
				{
					neighbors.Add(grid[checkX, checkY]);
				}
			}
		}

		return neighbors;
	}

	// This method takes in a position and assigns it to its worldPosition variable and it keeps track of the position even as it changes and spits it back out in the form of a grid coordinate
	public Node NodeFromWorldPoint(Vector3 worldPosition)
	{
		// Move coordinates in correct position
		float linearPosX = worldPosition.x - worldBottomLeft.x;
		float linearPosY = worldPosition.y - worldBottomLeft.y;
		
		// Get float value of positions in new coordinates
		float floatPosX = (linearPosX / nodeDiameter) - nodeRadius;
		float floatPosY = (linearPosY / nodeDiameter) - nodeRadius - 2;

		// Set x and y to the position of new coordinates
		int x = Mathf.RoundToInt(floatPosX);
		int y = Mathf.RoundToInt(floatPosY);

		// Sets x and y to proper grid coordinate with the needed -1 to compensate for the grid starting at zero
		x = Mathf.Clamp(x, 0, gridSizeX - 1);
		y = Mathf.Clamp(y, 0, gridSizeY - 1);

		// Exports the x and y coordinates to be used by the OnDrawGizmos method
		return grid[x, y];
	}

	// Makes the created grid visible with colors and gizmos to make things easier
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 0)); // Draws a wire cube that can be manipulated in the inspector

		// If there is a grid square here
		if (grid != null && displayGridGizmos)
		{
			// For every grid square
			foreach (Node n in grid)
			{
				Gizmos.color = (n.walkable) ? Color.blue : Color.red; // Color the square white unless it's unwalkable
				Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f)); // Draws a grid square here
			}
		}
	}
}