#pragma once

template <typename T>
class BubbleSort
{
public:
    static void sort(List<T> &list)
    {
        int n = list.size_of_list();

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                T first = list.getAt(j);
                T second = list.getAt(j + 1);

                if (first > second)
                {
                    // Swap the elements
                    list.set_at(second, j);
                    list.set_at(first, j + 1);
                }
            }
        }
    }
};
