#include "list.h"
#include "quick_sort.h"
#include <vector>
#include <cmath>

template <typename T>
class BucketSort
{
public:
    static void sort(List<T> &list)
    {
        std::cout << "Sorting..." << std::endl;
        int n = list.size_of_list();
        if (n <= 0)
            return;

        MinMaxValues minMax = findMinMax(list);
        std::cout << "Min: " << minMax.minVal << ", Max: " << minMax.maxVal << std::endl;

        std::vector<List<T>> buckets(floor(sqrt(n)));

        std::cout << "Number of buckets: " << buckets.size() << std::endl;

        distributeToBuckets(list, buckets, minMax.minVal, minMax.maxVal);
        sortBuckets(buckets);
        concatenateBuckets(list, buckets);
    }

private:
    struct MinMaxValues
    {
        T minVal;
        T maxVal;
    };

    static MinMaxValues findMinMax(const List<T> &list)
    {
        MinMaxValues minMax;
        minMax.maxVal = list.getAt(0);
        minMax.minVal = list.getAt(0);
        for (int i = 1; i < list.size_of_list(); i++)
        {
            if (list.getAt(i) > minMax.maxVal)
                minMax.maxVal = list.getAt(i);
            if (list.getAt(i) < minMax.minVal)
                minMax.minVal = list.getAt(i);
        }
        return minMax;
    }

    static void distributeToBuckets(const List<T> &list, std::vector<List<T>> &buckets, T minVal, T maxVal)
    {
        int n = list.size_of_list();
        int numBuckets = buckets.size();
        for (int i = 0; i < n; i++)
        {
            int bucketIndex = (list.getAt(i) - minVal) * (numBuckets - 1) / (maxVal - minVal);
            buckets[bucketIndex].insert(list.getAt(i));
        }
    }

    static void sortBuckets(std::vector<List<T>> &buckets)
    {
        for (int i = 0; i < buckets.size(); i++)
            QuickSort<T>::sort(buckets[i]);
    }

    static void concatenateBuckets(List<T> &list, const std::vector<List<T>> &buckets)
    {
        int index = 0;
        for (int i = 0; i < buckets.size(); i++)
        {
            for (int j = 0; j < buckets[i].size_of_list(); j++)
                list.set_at(buckets[i].getAt(j), index++);
        }
    }
};
