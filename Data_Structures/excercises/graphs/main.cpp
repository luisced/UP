struct node
{
    int val;
    int index;
};

struct edge
{
    int weight;
    node *nA;
    node *nB;
};

// Dijkstra
void Dijkstra(node *nodes, edge *edges, int origin)
{
    int costos[7] = { 1000,
                      1000,
                      1000,
                      1000,
                      1000,
                      1000,
                      1000 }
}

int main()
{
    // save the graph in array
    node nodes[7];
    edge edges[9] = {
        {2, &nodes[0], &nodes[1]},
        {6, &nodes[0], &nodes[2]},
        {5, &nodes[1], &nodes[3]},
        {8, &nodes[2], &nodes[3]},
        {10, &nodes[3], &nodes[5]},
        {15, &nodes[3], &nodes[4]},
        {6, &nodes[4], &nodes[5]},
        {6, &nodes[5], &nodes[6]},
        {2, &nodes[4], &nodes[6]},
    };

    // create nodes
    for (int i = 0; i < 7; i++)
        nodes[i].index = i;

    return 0;
}