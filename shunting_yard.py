'''
Simple Shunting Yard Algorithm
'''
operatorsMap = [ 
    ('+', 2),
    ('-', 2),
    ('*', 4),
    ('/', 4),
    ('^', 8)
]

def is_operator(x):
    val = None
    res = False

    for operator in operatorsMap:
        if x in operator:
            val = operator[1]
            res = True

    return res, val

def add_to_stack_or_queue(operators, operands, x, next_token_val):
    if len(operators) == 0:
        operators.insert(0, x)
    else:
        peek = operators[0]

        is_oper, prev_token_val = is_operator(peek)

        if is_oper:
            if next_token_val > prev_token_val:
                operators.insert(0, x)
            else:
                operators.remove(peek)
                operands.append(peek)

                add_to_stack_or_queue(operators, operands, x, next_token_val)
        else:
            raise Exception('Something goes wrong!')

def infix_to_postifx(expression):
    operators = []
    operands = []

    for x in expression.split(' '):
        is_oper, val = is_operator(x)

        if is_oper:
            add_to_stack_or_queue(operators, operands, x, val)
        else:
            operands.append(x)
    
    postfix = []

    while len(operands) > 0:
        operand_item = operands[0]
        postfix.append(operand_item)
        operands.remove(operand_item) 
    
    while len(operators) > 0:
        operator_item = operators[0]
        postfix.append(operator_item)
        operators.remove(operator_item)
    
    return ' '.join(postfix)


def calculate(postfix):
    print(postfix)

    operands = []

    for x in postfix.split(' '):
        is_oper, token_value = is_operator(x)
       
        if is_oper:
            val_1 = operands[1]
            val_2 = operands[0]
            operands.remove(val_1)
            operands.remove(val_2)

            if x == '+':
                operands.insert(0, val_1 + val_2)
            elif x == '-':
                operands.insert(0, val_1 - val_2)
            elif x == '*':
                operands.insert(0, val_1 * val_2)
            elif x == '/':
                operands.insert(0, val_1 / val_2)
            elif x == '^':
                operands.insert(0, val_1 ** val_2)

        else:
            operands.insert(0, int(x))

    print('Result is {0}'.format(operands[0]))

expression = '4 ^ 3 - 7 / 7'
postfix = infix_to_postifx(expression)
calculate(postfix)