using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SearchDFS
{
	public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
	{
		bool found = false;

		Stack<GraphNode> nodes = new Stack<GraphNode>();
		nodes.Push(source);

		// set found bool flag and the current number of s
		int steps = 0;
		while (!found && nodes.Count > 0 && steps++ < maxSteps)
		{
			// get top node of stack node (peek)
			GraphNode node = nodes.Peek(); // top of stack
			node.Visited = true;

			bool forward = false;
			// search node edges for unvisited node
			foreach (GraphNode.Edge edge in node.Edges)
			{
				// if node is unvisited then push on stack
				if (edge.nodeB.Visited == false)
				{
					nodes.Push(edge.nodeB);
					forward = true;
					// <set forward flag to true>
					if ( edge.nodeB == destination)
			        {
						found = true;
					}
					break;
				}
			}

			// if not moving forward, pop current node off stack
			if (forward == false)
			{
				// <pop stack>
				nodes.Pop();
			}
		}

		// convert stack path nodes to list
		path = new List<GraphNode>(nodes);
		// <reverse path list>
		path.Reverse();

		return found;

	}
}
