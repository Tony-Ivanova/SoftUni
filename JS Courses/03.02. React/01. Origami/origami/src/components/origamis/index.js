import React, { Component } from 'react'
import Origami from '../origami'
import styles from './index.module.css'

class Origamis extends Component {

    constructor(props) {
        super(props)

        this.state = {
            origamis: []
        }
    }

    getOrigamis = async () => {
        const origamis = await fetch('http://localhost:9999/api/origami')

        this.setState({
            origamis
        })
    }

    renderOrigamis() {
        const {
            origamis
        } = this.state

        return origamis.map(origami => {
            return (
               <Origami key={origami._id} {...origami}/>
            )
        })
    }

    componentDidMount() {
        this.getOrigamis()
    }

    render() {
        return (
            < div className={styles.container}>
                <h1 className={styles.title}>Origami 1</h1>
                <div className={styles["origamis-wrapper"]}>{this.renderOrigamis()}</div>
            </div >
        )
    }
}

export default Origamis