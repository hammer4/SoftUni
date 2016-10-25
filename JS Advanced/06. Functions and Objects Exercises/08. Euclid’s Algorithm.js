function euclidsAlgorithm(a, b){
    return b == 0 ? a : euclidsAlgorithm(b, a%b);
}
