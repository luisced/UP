
#include "list.h"
template <typename T>
class QuickSort
{
public:
    static void sort(List<T> &list)
    {
        sort(list, 0, list.size_of_list() - 1);
    }

private:
    static void sort(List<T> &list, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = partition(list, low, high);
            sort(list, low, pivotIndex - 1);
            sort(list, pivotIndex + 1, high);
        }
    }

    static int partition(List<T> &list, int low, int high)
    {
        T pivot = list.getAt(high);
        int i = low - 1;
        for (int j = low; j <= high - 1; j++)
        {
            if (list.getAt(j) < pivot)
            {
                i++;
                swap(list, i, j);
            }
        }
        swap(list, i + 1, high);
        return i + 1;
    }

    static void swap(List<T> &list, int i, int j)
    {
        T temp = list.getAt(i);
        list.set_at(list.getAt(j), i);
        list.set_at(temp, j);
    }
};
