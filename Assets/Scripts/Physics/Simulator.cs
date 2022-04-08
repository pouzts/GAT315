using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : Singleton<Simulator>
{
	[SerializeField] IntData fixedFPS;
	[SerializeField] StringData fps;
	[SerializeField] List<Force> forces;

	public List<Body> bodies { get; set; } = new List<Body>();
	Camera activeCamera;

	public float fixedDeltaTime => 1f / fixedFPS.value;
	float timeAccumulator = 0;

	private void Start()
	{
		activeCamera = Camera.main;
	}

	private void Update()
	{
		timeAccumulator += Time.deltaTime;

		forces.ForEach(force => force.ApplyForce(bodies));

		while (timeAccumulator > fixedDeltaTime)
		{ 
			bodies.ForEach(body =>
			{ 
				Integrator.SemiImplicitEuler(body, Time.deltaTime);
			});
			
			timeAccumulator -= fixedDeltaTime;
		}

		bodies.ForEach(body => body.acceleration = Vector2.zero);
		
		fps.value = (1f / Time.deltaTime).ToString("##.#");
    }

    public Vector3 GetScreenToWorldPosition(Vector2 screen)
	{
		Vector3 world = activeCamera.ScreenToWorldPoint(screen);
		return new Vector3(world.x, world.y, 0);
	}
}
