import React, { Component } from 'react';
import axios from 'axios';
import { Input, FormGroup, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table, Button } from 'reactstrap';

export default class Animal extends Component{
    AnimalURL = 'https://localhost:44319/api/Animal/';
    state = {
        animals: [],
        newAnimalData: {
        AnimalType: '',
        AnimalName: '',
        
        HumanID: ''
    },
    editAnimalData: {
      AnimalID: '',
      AnimalType: '',
      AnimalName: '',
      HumanID: ''
    },
    newAnimalModal: false,
    editModal: false
  }
  componentWillMount() {
    this._refreshAnimals();
  }

  componentDidMount() {
    this._refreshAnimals();
  }

  toggleNewAnimalModal() {
    this.setState({
      newAnimalModal: ! this.state.newAnimalModal
    });
  }
  toggleEditAnimalModal() {
    this.setState({
      editAnimalModal: ! this.state.editAnimalModal
    });
  }
  addAnimal() {
    axios.post(this.AnimalURL, this.state.newAnimalData).then((response) => {
      let { animals } = this.state;

      animals.push(response.data);
      this._refreshAnimals();
      this.setState({ animals, newAnimalModal: false, newAnimalData: {
        AnimalType: '',
        AnimalName: '',
        HumanID: ''
      }});
    });
  }
  updateAnimal() {
    let { AnimalType, AnimalName, HumanID } = this.state.editAnimalData;

    axios.put(this.AnimalURL + this.state.editAnimalData.AnimalID, {
      AnimalType, AnimalName, HumanID
    }).then((response) => {
      this._refreshAnimals();

      this.setState({
        editAnimalModal: false, editAnimalData: { AnimalID: '', AnimalType: '',  AnimalName: '',HumanID: '' }
      })
    });
  }
  editAnimal(id, animalType, animalName, humanID) {
    this.setState({
      editAnimalData: { AnimalID: id, AnimalType: animalType,  AnimalName: animalName, HumanID: humanID }, editAnimalModal: ! this.state.editAnimalModal
    });
  }
  deleteAnimal(animalID) {
    axios.delete(this.AnimalURL + animalID).then((response) => {
      this._refreshAnimals();
    });
  }
  _refreshAnimals() {
    axios.get(this.AnimalURL).then((response) => {
      this.setState({
        animals: response.data
      })
    });
  }
  render() {
    let animals = this.state.animals.map((animal) => {
      return (
        <tr key={animal.AnimalID}>
          <td>{animal.AnimalType}</td>
          <td>{animal.AnimalName}</td>
          <td>{animal.HumanID}</td>
          <td>
            <Button color="success" size="sm" className="mr-2" onClick={this.editAnimal.bind(this, animal.AnimalID, animal.AnimalType,  animal.AnimalName, animal.HumanID)}>Edit</Button>
            <Button color="danger" size="sm" onClick={this.deleteAnimal.bind(this, animal.AnimalID)}>Delete</Button>
          </td>
        </tr>
      )
    });
    return (
      <div className="App container">

      <h1>Animals App</h1>

      <Button className="my-3" color="primary" onClick={this.toggleNewAnimalModal.bind(this)}>Add animal</Button>

      <Modal isOpen={this.state.newAnimalModal} toggle={this.toggleNewAnimalModal.bind(this)}>
        <ModalHeader toggle={this.toggleNewAnimalModal.bind(this)}>Add a new animal</ModalHeader>
        <ModalBody>
        <FormGroup>
            <Label for="animalType">Animal type</Label>
            <Input id="animalType" value={this.state.newAnimalData.AnimalType} onChange={(e) => {
              let { newAnimalData } = this.state;

              newAnimalData.AnimalType = e.target.value;

              this.setState({ newAnimalData });
            }} />
          </FormGroup>
          <FormGroup>
            <Label for="animalName">Animal name</Label>
            <Input id="animalName" value={this.state.newAnimalData.AnimalName} onChange={(e) => {
              let { newAnimalData } = this.state;

              newAnimalData.AnimalName = e.target.value;

              this.setState({ newAnimalData });
            }} />
          </FormGroup>
          
          <FormGroup>
            <Label for="humanID">Owner ID</Label>
            <Input id="humanID" value={this.state.newAnimalData.HumanID} onChange={(e) => {
              let { newAnimalData } = this.state;

              newAnimalData.HumanID = e.target.value;

              this.setState({ newAnimalData });
            }} />
          </FormGroup>

        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={this.addAnimal.bind(this)}>Add animal</Button>{' '}
          <Button color="secondary" onClick={this.toggleNewAnimalModal.bind(this)}>Cancel</Button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={this.state.editAnimalModal} toggle={this.toggleEditAnimalModal.bind(this)}>
        <ModalHeader toggle={this.toggleEditAnimalModal.bind(this)}>Edit animal</ModalHeader>
        <ModalBody>
        <FormGroup>
            <Label for="animalType">Animal type</Label>
            <Input id="animalType" value={this.state.editAnimalData.AnimalType} onChange={(e) => {
              let { editAnimalData } = this.state;

              editAnimalData.AnimalType= e.target.value;

              this.setState({ editAnimalData });
            }} />
          </FormGroup>
          <FormGroup>
            <Label for="animalName">Animal name</Label>
            <Input id="animalName" value={this.state.editAnimalData.AnimalName} onChange={(e) => {
              let { editAnimalData } = this.state;

              editAnimalData.AnimalName = e.target.value;

              this.setState({ editAnimalData });
            }} />
          </FormGroup>
          
          <FormGroup>
            <Label for="humanID">Owner ID</Label>
            <Input id="humanID" value={this.state.editAnimalData.HumanID} onChange={(e) => {
              let { editAnimalData } = this.state;

              editAnimalData.HumanID= e.target.value;

              this.setState({ editAnimalData });
            }} />
          </FormGroup>

        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={this.updateAnimal.bind(this)}>Update animal</Button>{' '}
          <Button color="secondary" onClick={this.toggleEditAnimalModal.bind(this)}>Cancel</Button>
        </ModalFooter>
      </Modal>


        <Table>
          <thead>
            <tr>
              <th>Animal Type</th>
              <th>Animal name</th>
              <th>Owner ID</th>
              <th>Actions</th>
            </tr>
          </thead>

          <tbody>
            {animals}
          </tbody>
        </Table>
      </div>
    );
  }
}