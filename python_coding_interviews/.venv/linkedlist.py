class Node:
  def __init__(self, value, next = None):
    self.value = value
    self.next = next
  def getValue(self):
    return self.value
  def getNext(self):
    return self.next
  def setNext(self, next = None):
    self.next = next

root = Node(10)
root.setNext(Node(4))
root.getNext().setNext(Node(100))
while root:
  print(root.value)
  root = root.getNext()