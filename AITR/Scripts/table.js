var h1 = document.getElementsByTagName("table")[0];   // Get the first <h1> element in the document
var att = document.createAttribute("class");       // Create a "class" attribute
att.value = "containertable";                           // Set the value of the class attribute
h1.setAttributeNode(att);