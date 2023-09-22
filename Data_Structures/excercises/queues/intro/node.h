#include <string>
class Node
{
private:
    int val_int;
    char val_char;
    float val_float;
    std::string val_string;

public:
    char value;
    Node *next;
    int get_i()
    {
        return val_int;
    }
    char get_c()
    {
        return val_char;
    }
    float get_f()
    {
        return val_float;
    }
    std::string get_s()
    {
        return val_string;
    }

    void set(int val)
    {
        val_int = val;
    }
    void set(char val)
    {
        val_char = val;
    }
    void set(float val)
    {
        val_float = val;
    }
    void set(std::string val)
    {
        val_string = val;
    }
};
