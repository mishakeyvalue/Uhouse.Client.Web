import React, { Component } from 'react'
import { connect } from 'react-redux'

import PinControlPanel from './../components/PinControlPanel'

const mapStateToProps = state => ({
    pins: state.pins
});

const mapDispatchToProps = dispatch => ({
    turnOn: pinId => {
        console.log("It is turned on!");
        dispatch({type: 'TURN_ON', pinId: pinId})        
    },
    turnOff: pinId => {
        console.log("It is turned off!");
        dispatch({type: 'TURN_OFF', pinId: pinId})        
    }
})

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(PinControlPanel)