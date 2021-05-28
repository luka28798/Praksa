import React, { Component } from 'react';
//import axios from 'axios';
//import { Input, FormGroup, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table, Button } from 'reactstrap';
import Animal from "./Components/AnimalComponent";
class App extends Component {
  render(){
    return(
      <div>
        <Animal />
      </div>
      
    );
  }
}

export default App;