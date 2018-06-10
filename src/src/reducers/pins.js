import PinControl from "../components/PinControl";

let initialPins = () => {

    let generatePin = pinId => ({id: pinId, isEnabled: false})

    let pins = [];
    for(let i = 0; i < 15; i++) {
        let pin = generatePin(i);
        pins.push(pin);
    }
    return pins;
};

const pins = (state = initialPins(), action) => {

    let switchPin = newStatus => state.map(
        pin => 
          pin.id === action.pinId ? { ...pin, isEnabled: newStatus }: pin
    );

    switch (action.type) {
        case 'TURN_ON':
            return switchPin(true)
        case 'TURN_OFF':
            return switchPin(false)        
        default: return state;
    }
    return state;
}

export default pins;