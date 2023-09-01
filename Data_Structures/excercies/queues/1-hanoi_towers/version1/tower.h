#include <iostream>
#include <queue>

using namespace std;

class HanoiTower
{
public:
    void solve(int n, char from, char to, char empty_rod)
    {
        if (n == 1)
        {
            cout << "Move disk 1 from rod " << from << " to rod " << to << endl;
            return;
        }

        solve(n - 1, from, empty_rod, to);
        cout << "Move disk " << n << " from rod " << from << " to rod " << to << endl;
        solve(n - 1, empty_rod, to, from);
    }
};
