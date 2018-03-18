using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public DialogueFrame[] dialogueFrames;
    private Queue<DialogueFrame> dialogue = new Queue<DialogueFrame>();
    private DialogueFrame lastFrame;
    private DialogueFrame currentFrame;

    private bool hasNextFrame;
    private bool isfirstFrame;
    private DialogueFrame nextFrame;

    public Text leftNameText;
    public Image leftCharacterImage;
    private Animator leftImageAnimator;

    public Text rightNameText;
    public Image rightCharacterImage;
    private Animator rightImageAnimator;

    public Text dialogueText;


    public bool leftWillExit;
    public bool rightWillExit;

    private void Awake()
    {
        foreach (DialogueFrame frame in dialogueFrames)
        {
            dialogue.Enqueue(frame);
        }
        leftImageAnimator = leftCharacterImage.GetComponent<Animator>();
        rightImageAnimator = rightCharacterImage.GetComponent<Animator>();
        isfirstFrame = true;
        leftWillExit = false;
        rightWillExit = false;
        nextDialogueFrame();
    }


    public void nextDialogueFrame()
    {
        if (dialogue.Count == 0)
        {
            currentFrame = null;
            return;
        }
        else
        {
            //get next frame
            lastFrame = currentFrame;
            currentFrame = dialogue.Dequeue();
            if (dialogue.Count > 0)
            {
                hasNextFrame = true;
                nextFrame = dialogue.Peek();
            }
            else
            {
                hasNextFrame = false;
            }
            UpdateText();
            UpdateSprites();
            UpdateAnimationParameters();
        }
    }


    public void UpdateText() {

        //clear current names
        leftNameText.text = "";
        rightNameText.text = "";

        //show only the character who is speaking's name
        if (currentFrame.characterLeftIsSpeaking)
        {
            leftNameText.text = currentFrame.characterLeft.characterName;
        }
        else
        {
            rightNameText.text = currentFrame.characterRight.characterName;
        }

        //stops last typedialogue coroutine if player skips dialogue
        StopAllCoroutines();

        //starts typing dialogue for current frame
        StartCoroutine(TypeDialogue(currentFrame.dialogue));
        return;

    }



    public void UpdateSprites()
    {
        //get left character sprite and resize to be pixel perfect
        leftCharacterImage.sprite = currentFrame.characterLeft.sprite;
        leftCharacterImage.SetNativeSize();

        //get right character sprite and resive to be pixel perfect
        rightCharacterImage.sprite = currentFrame.characterRight.sprite;
        rightCharacterImage.SetNativeSize();

    }

    public void UpdateAnimationParameters() {
        if (leftWillExit)
        {
            leftWillExit = false;
            leftImageAnimator.SetTrigger("Exit");
        }
        if (rightWillExit)
        {
            rightWillExit = false;
            rightImageAnimator.SetTrigger("Exit");

        }
        //sync current frames speaking booleans with the animators
        leftImageAnimator.SetBool("IsSpeaking", currentFrame.characterLeftIsSpeaking);
        rightImageAnimator.SetBool("IsSpeaking", currentFrame.characterRightIsSpeaking);


        if (isfirstFrame)
        {
            isfirstFrame = false;
        }
        else
        {
            //if changing characters trigger exit animation
            if (lastFrame.characterLeft.GetHashCode() != currentFrame.characterLeft.GetHashCode())
            {
                leftImageAnimator.SetBool("IsEntering", true);
            }
            else
            {
                leftImageAnimator.SetBool("IsEntering", false);

            }
            if (lastFrame.characterRight.GetHashCode() != currentFrame.characterRight.GetHashCode())
            {
                rightImageAnimator.SetBool("IsEntering", true);
            }
            else
            {
                rightImageAnimator.SetBool("IsEntering", false);
            }
        }



        if (hasNextFrame)
        {
            //trigger enter animations for any character that is entering
            if (currentFrame.characterLeft.GetHashCode() != nextFrame.characterLeft.GetHashCode())
            {
                //TODO should be will exit on next frame 
                leftWillExit = true;
                //leftImageAnimator.SetTrigger("Exit");
            }
            else
            {
                //rightImageAnimator.SetBool("IsExiting", false);
            }
            if (currentFrame.characterRight.GetHashCode() != nextFrame.characterRight.GetHashCode())
            {
                //TODO should be will exit on next frame 
                rightWillExit = true;
                //rightImageAnimator.SetTrigger("Exit");
            }
            else
            {
                //rightImageAnimator.SetBool("IsExiting", false);
            }
        } 
    }

    //types one letter per frame into the dialogue text box
    IEnumerator TypeDialogue(string sentence)
    {

        //sets text box to empty
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }






}
