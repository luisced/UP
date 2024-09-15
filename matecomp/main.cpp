#include <iostream>
#include <set>

using namespace std;

// Define sets A = B = C = D = {1, 2, 3, 4}
set<int> A = {1, 2, 3, 4};

// Relations R, S, T
set<pair<int, int>> R = {{1, 1}, {1, 3}, {1, 4}, {2, 1}, {2, 2}, {2, 4}, {3, 2}, {3, 3}, {4, 1}, {4, 3}, {4, 4}};
set<pair<int, int>> S = {{1, 2}, {1, 3}, {2, 3}, {2, 4}, {3, 1}, {3, 2}, {3, 3}, {4, 2}, {4, 3}};
set<pair<int, int>> T = {{1, 3}, {1, 4}, {2, 1}, {2, 3}, {2, 4}, {3, 1}, {3, 2}, {4, 2}};

// Function to compute inverse of a relation
set<pair<int, int>> inverse_relation(const set<pair<int, int>>& rel) {
    set<pair<int, int>> inverse;
    for (const auto& p : rel) {
        inverse.insert(make_pair(p.second, p.first));
    }
    return inverse;
}

// Function to compute complement of a relation
set<pair<int, int>> complement_relation(const set<pair<int, int>>& rel, const set<int>& setA) {
    set<pair<int, int>> complement;
    for (int a : setA) {
        for (int b : setA) {
            if (rel.find(make_pair(a, b)) == rel.end()) {
                complement.insert(make_pair(a, b));
            }
        }
    }
    return complement;
}

// Function to compute intersection of two relations
set<pair<int, int>> intersection_relations(const set<pair<int, int>>& rel1, const set<pair<int, int>>& rel2) {
    set<pair<int, int>> intersection;
    for (const auto& p : rel1) {
        if (rel2.find(p) != rel2.end()) {
            intersection.insert(p);
        }
    }
    return intersection;
}

// Function to compute union of two relations
set<pair<int, int>> union_relations(const set<pair<int, int>>& rel1, const set<pair<int, int>>& rel2) {
    set<pair<int, int>> union_set = rel1;
    for (const auto& p : rel2) {
        union_set.insert(p);
    }
    return union_set;
}

// Function to compute relation composition
set<pair<int, int>> compose_relations(const set<pair<int, int>>& rel1, const set<pair<int, int>>& rel2) {
    set<pair<int, int>> result;
    for (const auto& p1 : rel1) {
        for (const auto& p2 : rel2) {
            if (p1.second == p2.first) {
                result.insert(make_pair(p1.first, p2.second));
            }
        }
    }
    return result;
}

// Print relation
void print_relation(const set<pair<int, int>>& rel) {
    for (const auto& p : rel) {
        cout << "(" << p.first << ", " << p.second << ") ";
    }
    cout << endl;
}

int main() {
    // Step 1: Compute S inverse
    set<pair<int, int>> S_inverse = inverse_relation(S);

    // Step 2: Compute R complement
    set<pair<int, int>> R_complement = complement_relation(R, A);

    // Step 3: Compute intersection S^-1 ∩ R
    set<pair<int, int>> intersection_S_inv_R = intersection_relations(S_inverse, R);

    // Step 4: Compute union T ∪ R'
    set<pair<int, int>> union_T_R_complement = union_relations(T, R_complement);

    // Step 5: Compute composition (S^-1 ∩ R)' ∘ (T ∪ R')
    set<pair<int, int>> complement_S_inv_intersection_R = complement_relation(intersection_S_inv_R, A);

    // Composition of (S^-1 ∩ R)' ∘ (T ∪ R')
    set<pair<int, int>> composition_result = compose_relations(complement_S_inv_intersection_R, union_T_R_complement);

    // Results
    cout << "S inverse: ";
    print_relation(S_inverse);

    cout << "R complement: ";
    print_relation(R_complement);

    cout << "S^-1 ∩ R: ";
    print_relation(intersection_S_inv_R);

    cout << "T ∪ R': ";
    print_relation(union_T_R_complement);

    cout << "Composition Result: ";
    print_relation(composition_result);

    return 0;
}

