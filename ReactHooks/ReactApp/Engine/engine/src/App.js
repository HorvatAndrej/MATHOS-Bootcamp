import React, { Component } from 'react';
import axios from 'axios';
import { Input, FormGroup, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table, Button } from 'reactstrap';

class App extends React.Component {
  state = {
    engines: [],
    newEngineData: {
      name: '',
      type: '',
      manufacturerId: ''

    },
    editEngineData: {
      id: '',
      name: '',
      type: ''
    },
    newEngineModal: false,
    editEngineModal: false
  }
  componentWillMount() {
    this._refreshEngines();
  }
  toggleNewEngineModal() {
    this.setState({
      newEngineModal: ! this.state.newEngineModal
    });
  }
  toggleEditEngineModal() {
    this.setState({
      editEngineModal: ! this.state.editEngineModal
    });
  }
  addBook() {
    axios.post('https://localhost:44379/api/engine/create', this.state.newEngineData).then((response) => {
      let { engines } = this.state;

      engines.push(response.data);

      this.setState({ engines, newEngineModal: false, newEngineData: {
        name: '',
        type: '',
        manufacturerId: ''
      }});
    });
  }
  updateEngine() {
    let { name, type } = this.state.editEngineData;

    axios.put('https://localhost:44379/api/engine/update' + this.state.editEngineData.id, {
      name,type
    }).then((response) => {
      this._refreshEngines();

      this.setState({
        editEngineModal: false, editEngineData: { id: '', name: '', type: '' }
      })
    });
  }
  editEngine(id, name, type) {
    this.setState({
      editEngineData: { id, name, type }, editEngineModal: ! this.state.editEngineModal
    });
  }
  deleteEngine(id) {
    axios.delete('https://localhost:44379/api/engine/delete' + id).then((response) => {
      this._refreshEngines();
    });
  }
  _refreshEngines() {
    axios.get('https://localhost:44379/api/engine/get?sortOrder=desc&columnName=Name&pageNumber=2&objectsPerPage=2&id=&name=').then((response) => {
      this.setState({
        engines: response.data
      })
    });
  }
  render() {
    let engines = this.state.engines.map((engine) => {
      return (
        <tr key={engine.id}>
          <td>{engine.id}</td>
          <td>{engine.name}</td>
          <td>{engine.type}</td>
          <td>{engine.manufacturerId}</td>
          <td>
            <Button color="success" size="sm" className="mr-2" onClick={this.editEngine.bind(this, engine.id, engine.name, engine.type, engine.manufacturerId)}>Edit</Button>
            <Button color="danger" size="sm" onClick={this.deleteEngine.bind(this, engine.id)}>Delete</Button>
          </td>
        </tr>
      )
    });
    return (
      <div className="App container">

      <h1>Engine App</h1>

      <Button className="my-3" color="primary" onClick={this.toggleNewEngineModal.bind(this)}>Add Engine</Button>

      <Modal isOpen={this.state.newEngineModal} toggle={this.toggleNewEnigneModal.bind(this)}>
        <ModalHeader toggle={this.toggleNewEngineModal.bind(this)}>Add a new Engine</ModalHeader>
        <ModalBody>
          <FormGroup>
            <Label for="name">Name</Label>
            <Input id="name" value={this.state.newEngineData.name} onChange={(e) => {
              let { newEngineData } = this.state;

              newEngineData.name = e.target.value;
              

              this.setState({ newEngineData });
            }} />
          </FormGroup>
          <FormGroup>
            <Label for="type">Type</Label>
            <Input id="type" value={this.state.newEngineData.type} onChange={(e) => {
              let { newEngineData } = this.state;

              newEngineData.type = e.target.value;

              this.setState({ newEngineData });
            }} />
          </FormGroup>
          <FormGroup>
            <Label for="manufacturerId">Manufacturer Id</Label>
            <Input id="manufacturerId" value={this.state.newEngineData.type} onChange={(e) => {
              let { newEngineData } = this.state;

              newEngineData.manufacturerId = e.target.value;

              this.setState({ newEngineData });
            }} />
          </FormGroup>

        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={this.addEngine.bind(this)}>Add Engine</Button>{' '}
          <Button color="secondary" onClick={this.toggleNewEngineModal.bind(this)}>Cancel</Button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={this.state.editEngineModal} toggle={this.toggleEditEngineModal.bind(this)}>
        <ModalHeader toggle={this.toggleEditEngineModal.bind(this)}>Edit a new engine</ModalHeader>
        <ModalBody>
          <FormGroup>
            <Label for="name">Name</Label>
            <Input id="name" value={this.state.editEngineData.title} onChange={(e) => {
              let { editEngineData } = this.state;

              editEngineData.name = e.target.value;

              this.setState({ editEngineData });
            }} />
          </FormGroup>
          <FormGroup>
            <Label for="type">Type</Label>
            <Input id="type" value={this.state.editEngineData.rating} onChange={(e) => {
              let { editEngineData } = this.state;

              editEngineData.rating = e.target.value;

              this.setState({ editEngineData });
            }} />
          </FormGroup>

        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={this.updateEngine.bind(this)}>Update Engine</Button>{' '}
          <Button color="secondary" onClick={this.toggleEngineBookModal.bind(this)}>Cancel</Button>
        </ModalFooter>
      </Modal>


        <Table>
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Type</th>
              <th>ManufacturerId</th>
            </tr>
          </thead>

          <tbody>
            {engines}
          </tbody>
        </Table>
      </div>
    );
  }
}

export default App;
