import {createSlice} from "@reduxjs/toolkit";

const ECarShopSlice = createSlice({
    name: 'cars',
    initialState: {
        cars: []
    },
    reducers:{
        AddCars(state, action) {
            
        },
        RemoveCars(state, action) {},
        toggleCarsComplete(state, action) {}
    },
});