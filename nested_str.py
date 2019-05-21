def nested_string(text):
    stack = []

    for item in text:
        if item == '{':
            stack.insert(0, item)

        elif item == '(':
            stack.insert(0, item)

        elif item == '[':
            stack.insert(0, item)

        elif item == '}':
            if len(stack) > 0 and stack[0] == '{':
                stack.remove('{')
            else:
                stack.insert(0, item)

        elif item == ')':
            if len(stack) > 0 and stack[0] == '(':
                stack.remove('(')
            else:
                stack.insert(0, item)

        elif item == ']':
            if len(stack) > 0 and stack[0] == '[':
                stack.remove('[')
            else:
                stack.insert(0, item)
    
    return False if len(stack) > 0 else True

stack = nested_string('([)()]')
print(stack)