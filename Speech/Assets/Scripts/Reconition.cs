using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;

public class Reconition : MonoBehaviour {

    //private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    [SerializeField]
    private GameObject Lion1;
    private Animator animatorLion1;
    [SerializeField]
    private GameObject Lion2;
    private Animator animatorLion2;
    [SerializeField]
    private GameObject Lion3;
    private Animator animatorLion3;

    [SerializeField]
    private AudioSource roarAudio;
    [SerializeField]
    private AudioSource singAudio;
    [SerializeField]
    private AudioSource jumpAudio;
    [SerializeField]
    private AudioSource runAudio;

    KeywordRecognizer keyWordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private int[] number = new int[2];
    private string operation = "plus";
    private int result;

    // Use this for initialization
    void Start() {
        //myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        animatorLion1 = Lion1.GetComponent<Animator>();
        animatorLion2 = Lion2.GetComponent<Animator>();
        animatorLion3 = Lion3.GetComponent<Animator>();

        keywords.Add("sit down", () =>
        {
            sitCalled();
        });
        keywords.Add("go", () =>
        {
            GoCalled();
        });
        keywords.Add("jump", () =>
        {
            jumpCalled();
        });
        keywords.Add("roar", () =>
        {
            roarCalled();
        });
        keywords.Add("sure", () =>
        {
            roarCalled();
        });
        keywords.Add("run", () =>
        {
            runCalled();
        });
        keywords.Add("roll", () =>
        {
            rollCalled();
        });
        keywords.Add("stop", () =>
        {
            stopCalled();
        });
        keywords.Add("die", () =>
        {
            dieCalled();
        });
        keywords.Add("ok", () =>
        {
            okCalled();
        });
        keywords.Add("sing", () =>
        {
            singCalled();
        });
        keywords.Add("hard", () =>
        {
            singCalled();
        });
        keywords.Add("one", () =>
        {
            numberCalled(1);
            print("one");
        });
        keywords.Add("two", () =>
        {
            numberCalled(2);
            print("two");
        });
        keywords.Add("three", () =>
        {
            numberCalled(3);
            print("three");
        });
        keywords.Add("four", () =>
        {
            numberCalled(4);
            print("four");
        });
        keywords.Add("five", () =>
        {
            numberCalled(5);
            print("five");
        });
        keywords.Add("six", () =>
        {
            numberCalled(6);
            print("six");
        });
        keywords.Add("seven", () =>
        {
            numberCalled(7);
            print("seven");
        });
        keywords.Add("eight", () =>
        {
            numberCalled(8);
            print("eight");
        });
        keywords.Add("nine", () =>
        {
            numberCalled(9);
            print("nine");
        });
        keywords.Add("ten", () =>
        {
            numberCalled(10);
            print("ten");
        });

        keywords.Add("plus", () =>
        {
            operation = "plus";
            print("plus");
        });
        keywords.Add("minus", () =>
        {
            operation = "minus";
            print("minus");
        });
        keywords.Add("and", () =>
        {
            operation = "plus";
            print("and");
        });
        keywords.Add("multiply", () =>
        {
            operation = "multiply";
            print("multiply");
        });
        keyWordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keyWordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognizer;
        keyWordRecognizer.Start();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            roarCalled();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            singCalled();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dieCalled();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stopCalled();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            sitCalled();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            numberCalled(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            numberCalled(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            numberCalled(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            numberCalled(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            numberCalled(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            numberCalled(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            numberCalled(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            numberCalled(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            numberCalled(9);
        }
    }

    void KeywordRecognizerOnPhraseRecognizer(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    void GoCalled()
    {
        print("You just said GO");
    }

    void sitCalled()
    {
        print("You just said sit");
        myAnimator.SetTrigger("Sit");
        animatorLion1.SetTrigger("Sit");
        animatorLion2.SetTrigger("Sit");
        animatorLion3.SetTrigger("Sit");
    }
    void jumpCalled()
    {
        myAnimator.SetTrigger("Jump");
        animatorLion1.SetTrigger("Jump");
        animatorLion2.SetTrigger("Jump");
        animatorLion3.SetTrigger("Jump");
        jumpAudio.Play();
    }

    void roarCalled()
    {
        myAnimator.SetTrigger("Roar");
        roarAudio.Play();
        animatorLion1.SetTrigger("Roar");
        animatorLion2.SetTrigger("Roar");
        animatorLion3.SetTrigger("Roar");
        stopCalled();
        
    }
    void runCalled()
    {
        myAnimator.SetBool("Run", true);
        animatorLion1.SetBool("Run", true);
        animatorLion2.SetBool("Run", true);
        animatorLion3.SetBool("Run", true);
        runAudio.Play();
    }
    void stopCalled()
    {
        myAnimator.SetBool("Run", false);
        animatorLion1.SetBool("Run", false);
        animatorLion2.SetBool("Run", false);
        animatorLion3.SetBool("Run", false);

        myAnimator.SetBool("Sing", false);
        animatorLion1.SetBool("Sing", false);
        animatorLion2.SetBool("Sing", false);
        animatorLion3.SetBool("Sing", false);


        myAnimator.SetBool("Die", false);
        animatorLion1.SetBool("Die", false);
        animatorLion2.SetBool("Die", false);
        animatorLion3.SetBool("Die", false);

        runAudio.Stop();
        singAudio.Stop();
    }
    void rollCalled()
    {
        myAnimator.SetTrigger("Roll");
        animatorLion1.SetTrigger("Roll");
        animatorLion2.SetTrigger("Roll");
        animatorLion3.SetTrigger("Roll");
    }
    void dieCalled()
    {
        myAnimator.SetBool("Die", true);
        animatorLion1.SetBool("Die", true);
        animatorLion2.SetBool("Die", true);
        animatorLion3.SetBool("Die", true);
    }
    void okCalled()
    {
        myAnimator.SetBool("Die", false);
        animatorLion1.SetBool("Die", false);
        animatorLion2.SetBool("Die", false);
        animatorLion3.SetBool("Die", false);

        myAnimator.SetBool("Sing", false);
        animatorLion1.SetBool("Sing", false);
        animatorLion2.SetBool("Sing", false);
        animatorLion3.SetBool("Sing", false);

        singAudio.Stop();
    }
    void singCalled()
    {
        myAnimator.SetBool("Sing", true);
        animatorLion1.SetBool("Sing", true);
        animatorLion2.SetBool("Sing", true);
        animatorLion3.SetBool("Sing", true);

        singAudio.Play();
    }
    void numberCalled(int num)
    {
        if (number[0] == 0)
        {
            number[0] = num;
        }
        else
        {
            number[1] = num;
            if (operation == "plus")
            {
                result = number[0] + number[1];
                print(result);
                StartCoroutine(WaitEndRoar(result));
            }
            else if (operation == "minus")
            {
                result = number[0] - number[1];
                if (result > 0)
                {
                    print(result);
                    StartCoroutine(WaitEndRoar(result));
                }
            }
            else if (operation == "multiply")
            {
                result = number[0] * number[1];
                if (result > 0)
                {
                    print(result);
                    StartCoroutine(WaitEndRoar(result));
                }
            }
            number[0] = 0;
            number[1] = 0;
            operation = "plus";
        }
    }

    IEnumerator WaitEndRoar(int numOfRoar)
    {
        for (int i = 0; i < numOfRoar; i++)
        {
            roarCalled();
            yield return new WaitForSeconds(1.52f);
        }
    }
}
