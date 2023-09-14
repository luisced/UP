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
    void get_i();
    char get_c();
    float get_f();
    std::string get_s();

    void set_i(int val);
    void set_c(char val);
    void set_f(float val);
    void set_s(std::string val);
};
