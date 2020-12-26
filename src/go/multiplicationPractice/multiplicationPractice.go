package main

import (
	"fmt"
	"math/rand"
	"os"
	"strconv"
	"bufio"
	"time"
	"strings"
)

type Problem struct {
	factor1 int
	factor2 int
}

func (problem *Problem) format() string {
	return fmt.Sprintf("%d x %d = ", problem.factor1, problem.factor2)
}

func generate(max int) *Problem {
	source := rand.NewSource(time.Now().UnixNano())
	rng := rand.New(source)
	p := Problem{
		factor1:rng.Intn(max),
		factor2:rng.Intn(max),
	}
	return &p
}

func check(answer string, problem *Problem) bool {
	parsed, err := strconv.ParseInt(answer, 10, 32)
	if err != nil {
		fmt.Printf("error: %s\n", err)
		return false
	} else {
		return parsed == int64(problem.factor1 * problem.factor2)
	}
}

func main() {
	reader := bufio.NewReader(os.Stdin)
	p := generate(12)
	for true {
		fmt.Printf(p.format())
		answer, err := reader.ReadString('\n')
		if err == nil {
			if check(strings.TrimSpace(answer), p) {
				p = generate(12)
			}
			continue
		}
	}
}
