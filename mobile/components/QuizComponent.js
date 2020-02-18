import React, { useState, useEffect, } from 'react';
import { StyleSheet, Text, TouchableOpacity, View, ScrollView } from 'react-native';
import RadioGroup, { Radio } from "react-native-radio-input";


export default function QuizComponent(props) {

    const { question } = props;
    return (
        <View key={question.id} style={styles.question}>
            <Text style={styles.questionTitle}>{question.description}</Text>
            <RadioGroup getChecked={props.getChecked}>
                {
                    question.answers.map(a => (
                        <Radio key={a.id} iconName={"lens"} label={a.description} value={`${question.id};${a.id};${a.correctly}`} />
                    ))
                }
            </RadioGroup>
        </View>
    );
}

const styles = StyleSheet.create({
    question: {
        marginBottom: 10,
        padding: 10,
        backgroundColor: '#fff'
    },
    questionTitle: {
        fontSize: 18
    },
    button: {
        alignItems: 'center',
        padding: 5,
        marginTop: 10,
        backgroundColor: '#4d0250',
        width: 100,
        marginBottom: 10,
        borderRadius: 3
    },
    buttonText: {
        color: 'white'
    }
})